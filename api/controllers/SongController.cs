using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using api.models;
using api.database;
// using api.interfaces;


namespace api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        // GET: api/song
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Songs> Get()
        {
            List<Songs> songs = new List<Songs>();
            ReadSong readingsong = new ReadSong();
            songs = readingsong.GetAll();

            return songs;
        }
        // GET: api/song/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetPost")]
        public Songs Get(int id)
        {
            return new Songs();
            // IGetPost read = new ReadPostData();
            // return read.Get(id);
        }

        // POST: api/song
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostSongs")]
        public void Post(Songs song)
        {
            UpdateSong updating = new UpdateSong();
            updating.Update(song);
            // IAddPost add = new AddPost();
            // add.Add(p);
        }

        // PUT: api/song/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Songs song)
        {
            createnewsong creating = new createnewsong();
            creating.Create(song);
            // IEditPost edit = new EditPost();
            // edit.Edit(p);
        }

        // DELETE: api/song/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteSong deleting = new DeleteSong();
            deleting.Delete(id);
            // IDeletePost delete = new DeletePost();
            // delete.Delete(id);
        }
    }
}