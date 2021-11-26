using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Models
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public void Add(string _Name, string _Description, int _Rating, DateTime _ReleaseDate, double _Price, int _PublisherId, int _DeveloperId)
        {
            throw new NotImplementedException();
        }

        public void Edit(int _Id, string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(int _Id)
        {
            throw new NotImplementedException();
        }

        List<OperatingSystem> IProductRepository.GetList()
        {
            throw new NotImplementedException();
        }
    }

    public class OperatingSystemRepository : IOperatingSystemRepository
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public IEnumerable<object> GetList()
        {
            return Context.OperatingSystems.ToList();
        }

        public void Input(OperatingSystem Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            if (Model.Id == -1)
            {
                OperatingSystem NewOS = new Models.OperatingSystem();
                NewOS.Name = Model.Name;
                Context.OperatingSystems.Add(NewOS);
                Context.SaveChanges();
            }
            else
            {
                Context.OperatingSystems.Find(Model.Id).Name = Model.Name;
                Context.SaveChanges();
            }
        }

        public void Remove(int _Id)
        {
            throw new NotImplementedException();
        }
    }

    public class PublisherRepository : IPublisherRepository
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public void Add(string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public void Edit(int _Id, string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(int _Id)
        {
            throw new NotImplementedException();
        }
    }

    public class DeveloperRepository : IDeveloperRepository
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public void Add(string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public void Edit(int _Id, string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(int _Id)
        {
            throw new NotImplementedException();
        }
    }

    public class FileRepository : IFileRepository
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public void Add(string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public void Edit(int _Id, string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(int _Id)
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public void Add(string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public void Edit(int _Id, string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(int _Id)
        {
            throw new NotImplementedException();
        }
    }

    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public void Add(string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public void Edit(int _Id, string _Name, string _Description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(int _Id)
        {
            throw new NotImplementedException();
        }
    }
}