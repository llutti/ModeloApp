using System;
using Application.Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services;
using Service.Validators;

namespace Application.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private BaseService<User> service;

    public UserController(SqlLiteContext context)
    {
      service = new BaseService<User>(context);
    }

    [HttpPost]
    public IActionResult Post([FromBody] User item)
    {
      try
      {
        service.Post<UserValidator>(item);

        return new ObjectResult(item);
      }
      catch (ArgumentNullException ex)
      {
        return NotFound(ex);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpPut]
    public IActionResult Put([FromBody] User item)
    {
      try
      {
        service.Put<UserValidator>(item);

        return new ObjectResult(item);
      }
      catch (ArgumentNullException ex)
      {
        return NotFound(ex);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        service.DeleteAsync(id);

        return new NoContentResult();
      }
      catch (ArgumentException ex)
      {
        return NotFound(ex.Message);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        return new ObjectResult(service.GetAsync().Result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      try
      {
        var item = service.GetAsync(id);

        if (item.Result == null)
        {
          return NotFound($"ID '{id}' can´t be found.");
        }

        return new ObjectResult(item.Result);
      }
      catch (ArgumentException ex)
      {
        return NotFound(ex.Message);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}