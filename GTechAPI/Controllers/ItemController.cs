using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GTechAPI.DTO.ItemDTO;
using GTechAPI.Entities;
using GTechAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTechAPI.Controllers
{
    [ApiController]
    public class ItemController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemController(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> InsertBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            //var baseBook = mapper.Map<BaseMetadatum>(baseMetadatumDTO);
            await _itemRepository.InsertBook(book);

            var bookToMap = _mapper.Map<BookDTO>(book);
            //var baseToMap = mapper.Map<BaseMetadatumDTO>(baseBook);


            return bookToMap;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItembyID(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            var itemToReturn = _mapper.Map<ItemDTO>(item);

            return Ok(itemToReturn);
        
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
        {
            var items = await _itemRepository.GetAvailableItemsAsync();

            var itemsToReturn = _mapper.Map<IEnumerable<ItemDTO>>(items);

            return Ok(itemsToReturn);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/books")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var items = await _itemRepository.GetBooksAsync();

            var itemsToReturn = _mapper.Map<IEnumerable<BookDTO>>(items);

            return Ok(itemsToReturn);
        }
    }
}
