using ApiTeste.Business.Interfaces;
using ApiTeste.Business.Models;
using ApiTeste.DTO;
using ApiTeste.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IUtilsServices _utilsServices;
        private readonly IMapper _mapper;
        public ContatoController(IContatoRepository contatoRepository, IUtilsServices utilsServices, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _utilsServices = utilsServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> GetContactsAll()
        {
            var Contatos = await _contatoRepository.GetContatoAtivoList();
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_utilsServices.CalculateAgeList(Contatos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoViewModel>> GetContact(Guid id)
        {
            var contato = await _contatoRepository.GetById(id);
            var contatoViewModel = _mapper.Map<ContatoViewModel>(contato);
            if (contato == null)
                return NotFound("Contato inexistente!");

            contatoViewModel.Idade = _utilsServices.CalculateAge(contato.DataNascimento);
            if (!contatoViewModel.IsAtivo) { return BadRequest("Não é possivel acessar dados de contatos inativos!"); }
            return contatoViewModel;
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<ContatoDTO>> Deactivate(Guid id)
        {
            if (!ContactExist(id))
                return NotFound("Contato inexistente!");

            return _mapper.Map<ContatoDTO>(await _contatoRepository.DisableActive(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditContact(Guid id, ContatoDTO contatoDTO)
        {
            if (id != contatoDTO.Id)
                return BadRequest("");
            try
            {
                var contato = _mapper.Map<Contato>(contatoDTO);
                await _contatoRepository.Update(contato);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExist(id))
                    return NotFound("Algo Inesperado ocorreu!");
                else
                    throw;
            }
            return Ok("Contato alterado com sucesso");
        }
        [HttpPost]
        public async Task<ActionResult<ContatoViewModel>> CreateContact(ContatoDTO contatoDTO)
        {
            if (!_utilsServices.CheckDateBirday(contatoDTO.DataNascimento))
                return BadRequest("Data de nascimento invalida maior que a data atual!");

            if (!_utilsServices.CheckMajority(contatoDTO.DataNascimento))
                return BadRequest("Não é permitido cadastrar menores de 18!");

            var contato = _mapper.Map<Contato>(contatoDTO);
            await _contatoRepository.Add(contato);
            var contatoViewModel = _mapper.Map<ContatoViewModel>(contato);
            contatoViewModel.Idade = _utilsServices.CalculateAge(contatoDTO.DataNascimento);
            return CreatedAtAction("GetContact", new { id = contato.Id }, contatoViewModel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(Guid id)
        {
            if (!ContactExist(id))
                return NotFound("Contato inexistente!");
            await _contatoRepository.Delete(id);
            return Ok("Contato excluido!");
        }
        private bool ContactExist(Guid id)
        {
            return _contatoRepository.Exister(p => p.Id == id).Result.Any();
        }
    }
}