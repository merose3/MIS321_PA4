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
        public List<Songs> Get() //this is going to get all of the songs from the database 
        {
            List<Songs> songs = new List<Songs>();
            ReadSong readingsong = new ReadSong();
            songs = readingsong.GetAll();

            return songs;
        }
        // GET: api/song/5
        [EnableCors("OpenPolicy")] //this is done this one works
        [HttpGet("{id}", Name = "GetPost")]
        public Songs Get(int id) //read
        {
            return new Songs();
            // IGetPost read = new ReadPostData();
            // return read.Get(id);
        }

        // POST: api/song
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Songs song)  //Post = create
        {
            //System.Console.WriteLine("made it to post");
            createnewsong creating = new createnewsong();
            creating.Create(song.SongTitle);
            // IAddPost add = new AddPost();
            // add.Add(p);
        }

        // PUT: api/song/5 
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id) //update & favorite LETS HOPE THIS WORKS
        {
            UpdateSong updating = new UpdateSong();
            updating.Update(id); //this is sus
            // IEditPost edit = new EditPost();
            // edit.Edit(p);
        }

        // DELETE: api/song/5
        [EnableCors("OpenPolicy")] //this is now using the LIST of songs song
        [HttpDelete("{id}")]
        public void Delete(int id) //delete & this is already doing a soft delete from when in the crud methods 
        {//[FromBody]
            DeleteSong deleting = new DeleteSong();
            deleting.Delete(id);
            // IDeletePost delete = new DeletePost();
            // delete.Delete(id);
        }
    }
}