using Encuestadiego.Contexts;
using Encuestadiego.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuestadiego.Controllers
{
    [Route("api/pruebas")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public EncuestaController(ConexionSQLServer context)
        {
            this.context = context;
        }




        [HttpGet]
        public async Task<ActionResult<List<EncuestaEntity>>> Get()
        {
            var listEncuesta = await GetListEncuesta();
            if(listEncuesta.Count < 0)
                return NotFound();
            return listEncuesta;

        }


        [HttpPost]
        public  async Task<ActionResult<List<EncuestaEntity>>> Post(EncuestaEntity encuestaEntity)
        {
            var listEncuesta = await GetListEncuesta();
            context.Encuestas.Add(encuestaEntity);
            context.SaveChangesAsync();


            return listEncuesta;
        }

        [HttpPut]
        public async Task<ActionResult<List<EncuestaEntity>>> Put(EncuestaEntity encuestaEntity)
        {
            var listEncuesta = await GetListEncuesta();
            var encuestaUpdte = listEncuesta.Find(u => u.Id == encuestaEntity.Id);
            if (encuestaUpdte == null)
                return NotFound();
            listEncuesta.First(u => u.Id == encuestaUpdte.Id).campo = encuestaEntity.campo;
            listEncuesta.First(u => u.Id == encuestaUpdte.Id).titulo = encuestaEntity.titulo;
            listEncuesta.First(u => u.Id == encuestaUpdte.Id).requerido = encuestaEntity.requerido;
            listEncuesta.First(u => u.Id == encuestaUpdte.Id).tipcampo = encuestaEntity.tipcampo;


            context.Encuestas.Update(encuestaUpdte); 
            context.SaveChangesAsync();


            return listEncuesta;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EncuestaEntity>>> Delete(int id)
        {
            var listEncuesta = await GetListEncuesta();
            var encuestaDelete = listEncuesta.Find(u => u.Id == id);
            if (encuestaDelete == null)
                return NotFound();

            listEncuesta.Remove(encuestaDelete);
            context.Encuestas.Remove(encuestaDelete);
            context.SaveChangesAsync();

            return listEncuesta;

        }


        private async Task<List<EncuestaEntity>> GetListEncuesta()
        {
         
            return context.Encuestas.ToList();
        }

    }
}
