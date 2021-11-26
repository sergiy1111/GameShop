using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesShop.Models;

namespace GamesShop.Models
{
    public interface IRepository
    {    
        void Remove(int _Id);
        IEnumerable<object> GetList();
    }

    public interface IProductRepository : IRepository
    {
        void Add(string _Name, string _Description, int _Rating, DateTime _ReleaseDate, double _Price, int _PublisherId, int _DeveloperId);
        void Edit(int _Id, string _Name, string _Description);
        List<OperatingSystem> GetList();
    }

    public interface IOperatingSystemRepository : IRepository
    {
        void Input(OperatingSystem Model);
    }

    public interface IPublisherRepository : IRepository
    {
        void Add(string _Name, string _Description);
        void Edit(int _Id, string _Name, string _Description);
    }

    public interface IDeveloperRepository : IRepository
    {
        void Add(string _Name, string _Description);
        void Edit(int _Id, string _Name, string _Description);
    }
    public interface IFileRepository : IRepository
    {
        void Add(string _Name, string _Description);
        void Edit(int _Id, string _Name, string _Description);
    }
    public interface ICategoryRepository : IRepository
    {
        void Add(string _Name, string _Description);
        void Edit(int _Id, string _Name, string _Description);
    }
    public interface ICommentRepository : IRepository
    {
        void Add(string _Name, string _Description);
        void Edit(int _Id, string _Name, string _Description);
    }

}