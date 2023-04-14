using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> Get()
        {
            return await this.repo.GetDepartamentosAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }

        //EXISTEN METODOS QUE SON POR DEFECTO PARA POST, PUT Y DELETE
        //LOS DOS PRIMEROS METODOS RECIBEN OBJETOS
        //EL METODO DELETE RECIBE UN ID, IGUAL QUE GET(ID)
        //SI QUISIERAMOS RECIBIR EL OBJETO POR PARAMETROS
        //DEBEMOS HACERLO CON [Route]
        //AL DEVOLVER UN ACTION





        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult>
            InsertarDepartamento(Departamento departamento)
        {
            await this.repo.InsertarDepartamento(departamento.IdDepartamento,
                departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult>UpdateDepartamento(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento,
                departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmpleados(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return Ok();
        }
    }
}
