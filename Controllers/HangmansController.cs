using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hangman_c.Models;
using hangman_c.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hangman_c.Controllers
{

    [Route("api/[controller]")]
    public class HangmansController : Controller
    {
        private readonly HangmanRepository db;
        public HangmansController(HangmanRepository hangmanRepo)
        {
            db = hangmanRepo;
        }
        [HttpGet]

      
       [HttpGet("{id}")]
       public Hangman Get(int id)
       {
           return db.GetById(id);
       }

      
       [HttpPost]
       public Hangman Post([FromBody]Hangman hangman)
       {
           return db.Add(hangman);
       }

      
       [HttpPut("{id}")]
       public Hangman Put(int id, [FromBody]Hangman hangman)
       {
           if (ModelState.IsValid)
           {
               return db.GetOneByIdAndUpdate(id, hangman);
           }
           return null;
       }

       
       [HttpDelete("{id}")]
       public string Delete(int id)
       {
           return db.FindByIdAndRemove(id);
       }
    }
}