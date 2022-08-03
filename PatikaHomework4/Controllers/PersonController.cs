﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatikaHomework4.Data.Model;
using PatikaHomework4.Dto.Dto;
using PatikaHomework4.Dto.Response;
using PatikaHomework4.Service.IServices;

namespace PatikaHomework4.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
       


        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
          

        }




        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retuns data </response>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<Person>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var person = await Task.Run(() => _personService.GetAll());
            GenericResponse<IEnumerable<Person>> response = new GenericResponse<IEnumerable<Person>>();
            response.Success = true;
            response.Message = null;
            response.Data = person;

            return Ok(response);

        }


        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retuns data </response>
        /// <response code="404">Returns error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
           
            var person = await Task.Run(() => _personService.GetById(id));
            GenericResponse<Person> response = new GenericResponse<Person>();

            if (person == null)
            {
                response.Success = false;
                response.Message = "Does not exist.";
                response.Data = null;
                return NotFound(response);
            }
            response.Success = true;
            response.Message = null;
            response.Data = person;
            return Ok(response);

        }


        /// <summary>
        /// post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="201">Retuns data </response>
        /// <response code="404">Returns error</response>
        /// <response code="400">Returns error</response>
        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(PersonDto model)
        {

            GenericResponse<Person> response = new GenericResponse<Person>();
            var entity = _mapper.Map<PersonDto, Person>(model);

            //if (!ValidationHelper.IsValidEmail(model.Email) && !ValidationHelper.IsPhoneNumber(model.Phone))
            //{
            //    response.Success = false;
            //    response.Message = "Maill adress or phone number is invalid.";
            //    response.Data = null;
            //    return BadRequest(response);
            //}


            var result = await Task.Run(() => _personService.Add(entity));

            if (result == null)
            {
                response.Success = false;
                response.Message = "An error ocurred.";
                response.Data = null;
                return BadRequest(response);
            }
            response.Success = true;
            response.Message = null;
            response.Data = result;

            return Created("", response);


        }



        /// <summary>
        /// update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Retuns data </response>
        /// <response code="404">Returns error</response>
        /// <response code="400">Returns error</response>
        [HttpPatch]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(int id,PersonDto model)
        {
            
            GenericResponse<Person> response = new GenericResponse<Person>();
            var person = await Task.Run(() => _personService.GetById(id));
            if (person == null)
            {
                response.Success = false;
                response.Message = "Does not exist. Please check id.";
                response.Data = null;
                return NotFound(response);
            }

            var entity = _mapper.Map<PersonDto, Person>(model);

            //if (!ValidationHelper.IsValidEmail(model.Email) && !ValidationHelper.IsPhoneNumber(model.Phone))
            //{
            //    response.Success = false;
            //    response.Message = "Maill adress or phone number is invalid.";
            //    response.Data = null;
            //    return BadRequest(response);
            //}

            var result = await Task.Run(() => _personService.Add(entity));

            if (result == null)
            {
                response.Success = false;
                response.Message = "An error occured.";
                response.Data = null;
                return BadRequest(response);
            }

            response.Success = true;
            response.Message = null;
            response.Data = result;
            return Ok(response);

        }


        /// <summary>
        /// post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="201">Retuns data </response>
        /// <response code="404">Returns error</response>
        /// <response code="400">Returns error</response>
        [HttpPut]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(PersonDto model)
        {
            
            GenericResponse<Person> response = new GenericResponse<Person>();
            var entity = _mapper.Map<PersonDto, Person>(model);
            //if (!ValidationHelper.IsValidEmail(model.Email) && !ValidationHelper.IsPhoneNumber(model.Phone))
            //{
            //    response.Success = false;
            //    response.Message = "Maill adress or phone number is invalid.";
            //    response.Data = null;
            //    return BadRequest(response);
            //}


            var result = await Task.Run(() => _personService.Add(entity));

            if (result == null)
            {
                response.Success = false;
                response.Message = "An error ocurred.";
                response.Data = null;
                return BadRequest(response);
            }
            response.Success = true;
            response.Message = null;
            response.Data = result;

            return Created("", response);

        }


        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retuns data </response>
        /// <response code="404">Returns error</response>
        [HttpDelete]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponse<Person>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            
            GenericResponse<String> response = new GenericResponse<String>();
            var person = await Task.Run(() => _personService.GetById(id));
            if (person == null)
            {
                response.Success = false;
                response.Message = "Does not exist.";
                response.Data = null; ;
                return NotFound(response);
            }

            var result = await Task.Run(() => _personService.Delete(person.Id));

            if (result == null)
            {
                response.Success = false;
                response.Message = "Does not exist.";
                response.Data = null; ;
                return NotFound(response);
            }

            response.Success = true;
            response.Message = result;
            response.Data = null;
            return Ok(response);


        }
    }
}