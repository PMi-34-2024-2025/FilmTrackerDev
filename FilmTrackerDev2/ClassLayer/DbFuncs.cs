using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FilmTrackerDev2.ClassLayer
{
    public class DbFuncs
    {
        private readonly TrackerDbContext _context;

        // Конструктор, через який передається DbContext
        public DbFuncs(TrackerDbContext context)
        {
            _context = context;
        }

        public List<FilmObject> GetFilmObjects(int userId)
        {
            var films = _context.Films
                .Select(film => new FilmObject
                {
                    FilmId = film.FilmId,
                    Name = film.Name_,
                    Description = film.Description,
                    year = film.Year_,
                    comment = "",

                    // Витягнути рейтинг із View_Table (врахувати відсутність записів)
                    Rating = _context.Views
                        .Where(view => view.FilmId == film.FilmId)
                        .Select(view => view.Rating.HasValue ? (double)view.Rating.Value : 0.0)
                        .DefaultIfEmpty() // Використання DefaultIfEmpty для IQueryable
                        .Average(),

                    // Інші властивості
                    IsWatched = _context.Views.Any(view => view.FilmId == film.FilmId && view.UserId == userId && view.IsWatched),
                    IsPlanned = _context.Views.Any(view => view.FilmId == film.FilmId && view.UserId == userId && view.IsPlanned),
                    IsFavorite = _context.Views.Any(view => view.FilmId == film.FilmId && view.UserId == userId && view.IsFavorite),

                    Actors = _context.ActorFilms
                        .Where(af => af.FilmId == film.FilmId)
                        .Join(_context.Actors,
                            af => af.ActorId,
                            actor => actor.ActorId,
                            (af, actor) => new ActorObject
                            {
                                Name = actor.Name_,
                                id = actor.ActorId
                            })
                        .ToList(),
                })
                .ToList();

            return films;
        }

        public List<FilmObject> GetPlannedFilms(int userId)
        {
            var plannedFilms = _context.Films
                .Join(_context.Views,
                    film => film.FilmId,
                    view => view.FilmId,
                    (film, view) => new { Film = film, View = view })
                .Where(joined => joined.View.UserId == userId && joined.View.IsPlanned)
                .Select(joined => new FilmObject
                {
                    FilmId = joined.Film.FilmId,
                    Name = joined.Film.Name_,
                    Description = joined.Film.Description
                })
                .ToList();

            return plannedFilms;
        }

        public bool LoginCheck(string? username, string? password)
        {
            var UserObject = _context.Users.FirstOrDefault(ut => ut.UserName == username);
            string password_ = UserObject.Password_;
            int userId = UserObject.UserId;
            if (password == password_) 
            {
                App.CurrentUserId = userId;
                return true; 
            }
            else
            {
                return false;
            }
        }

        public void ChangePlannedCheckbox(int userId,int filmId, bool isPlanned)
        {
            // Знайти відповідний запис у View_Table
            var view = _context.Views
                .FirstOrDefault(v => v.UserId == userId && v.FilmId == filmId);

            if (view != null)
            {
                // Оновити значення IsPlanned
                view.IsPlanned = isPlanned;

                // Зберегти зміни в базу даних
                _context.SaveChanges();
            }
        }

        public void CreateOrCheckView(FilmObject film, int userId)
        {
            var existingView = _context.Views
                .FirstOrDefault(v => v.UserId == userId && v.FilmId == film.FilmId);

            // Якщо запису немає, створюємо новий
            if (existingView == null)
            {
                var newView = new ViewTable
                {
                    UserId = userId,
                    FilmId = film.FilmId,
                    Rating = 0, // За необхідності встановіть значення за замовчуванням
                    Comment_ = "",
                    IsPlanned = false, // Початкові значення
                    IsWatched = false,
                    IsFavorite = false
                };

                _context.Views.Add(newView);
                _context.SaveChanges(); // Зберігаємо зміни у базу даних
            }
        }

        public void ChangeFavoriteCheckbox(int userId, int filmId, bool isFavorite)
        {
            var view = _context.Views
                .FirstOrDefault(v => v.UserId == userId && v.FilmId == filmId);

            if (view != null)
            {
                // Оновити значення IsPlanned
                view.IsFavorite = isFavorite;

                // Зберегти зміни в базу даних
                _context.SaveChanges();
            }
        }

        public List<FilmObject> GetWatchListFilms(int userId)
        {
            var watchedFilms = _context.Views
                .Where(view => view.UserId == userId && view.IsWatched) // Фільтруємо за UserId та IsWatched
                .Select(view => new FilmObject
                {
                    FilmId = view.FilmId,
                    Name = _context.Films.FirstOrDefault(f => f.FilmId == view.FilmId).Name_, // Назва фільму
                    Description = _context.Films.FirstOrDefault(f => f.FilmId == view.FilmId).Description, // Опис фільму

                    // Статуси беруться прямо з View_Table
                    IsWatched = view.IsWatched,
                    IsPlanned = view.IsPlanned,
                    IsFavorite = view.IsFavorite,

                    // Рейтинг витягується прямо з запису View_Table
                    Rating = view.Rating.HasValue ? view.Rating.Value : 0.0 }).ToList();
            return watchedFilms;
        }

        public void ChangeWatchedCheckbox(int userId, int filmId, bool isWatched)
        {
            var view = _context.Views
                .FirstOrDefault(v => v.UserId == userId && v.FilmId == filmId);

            if (view != null)
            {
                // Оновити значення IsPlanned
                view.IsWatched = isWatched;

                // Зберегти зміни в базу даних
                _context.SaveChanges();
            }
        }

        public void UpdateViewTableRecord( FilmObject film, int userId)
        {
            // Знайти запис у таблиці ViewTable
            var viewRecord = _context.Views
                .FirstOrDefault(v => v.UserId == userId && v.FilmId == film.FilmId);

            if (viewRecord != null)
            {
                // Оновити значення
                viewRecord.IsWatched = true;
                viewRecord.IsPlanned = false;
                viewRecord.IsFavorite = film.IsFavorite;
                viewRecord.Rating = (int?)film.Rating; // Оновлюємо рейтинг, якщо він заданий
                viewRecord.Comment_ = film.comment; // Оновлюємо коментар, якщо він є
                

                // Зберегти зміни в базу даних
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Запис для фільму не знайдено у ViewTable.");
            }
        }


        public bool RegistrationCheck(string username, string password)
        {
            if (_context.Users.FirstOrDefault(un => un.UserName == username)?.UserName == null)
            {
                var UserTable = new UserTable
                {
                    UserName = username,
                    Password_ = password
                };
                _context.Users.Add(UserTable);
                _context.SaveChanges();
                int userId = _context.Users.FirstOrDefault(un => un.UserName == username).UserId;
                App.CurrentUserId = userId;
                return true;
            }
            return false;
        }
    }
}

