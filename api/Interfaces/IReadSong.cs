using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interfaces
{
    public interface IReadSong
    {
        public List<Songs> GetAll();
        public Songs GetOne(int id);
    }
}