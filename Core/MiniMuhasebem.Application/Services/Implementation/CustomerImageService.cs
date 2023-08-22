using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniMuhasebem.Application.Behaviors;
using MiniMuhasebem.Application.Exceptions;
using MiniMuhasebem.Application.Models.Dtos.CustomerImageDtos;
using MiniMuhasebem.Application.Models.RequestModels.CustomerImageRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Validators.CustomerImagesValidators;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using MiniMuhasebem.Domain.UWork;
using MiniMuhasebem.Utils;




namespace MiniMuhasebem.Application.Services.Implementation
{
    public class CustomerImageService : ICustomerImageService
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public CustomerImageService(IUnitWork unitWork, IMapper mapper, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitWork = unitWork;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        [ValidationBehavior(typeof(GetAllCustomerImageByCustomerValidator))]
        public async Task<Result<List<CustomerImageDto>>> GetAllImagesByCustomer(GetAllCustomerImageByCustomerVM getByCustomerVM)
        {
            var result = new Result<List<CustomerImageDto>>();

            var CustomerImageEntities = await _unitWork.GetRepository<CustomerImage>().GetByFilterAsync(x => x.CustomerId == getByCustomerVM.CustomerId);
            var CustomerImageDtos = await CustomerImageEntities.ProjectTo<CustomerImageDto>(_mapper.ConfigurationProvider).ToListAsync();

            result.Data = CustomerImageDtos;
            return result;
        }


        [ValidationBehavior(typeof(GetAllCustomerImageByCustomerValidator))]
        public async Task<Result<List<CustomerImageWithCustomerDto>>> GetAllCustomerImagesWithCustomer(GetAllCustomerImageByCustomerVM getByCustomerVM)
        {
            var result = new Result<List<CustomerImageWithCustomerDto>>();

            var CustomerImageEntities = await _unitWork.GetRepository<CustomerImage>().GetByFilterAsync(x => x.CustomerId == getByCustomerVM.CustomerId);
            var CustomerImageDtos = await CustomerImageEntities.ProjectTo<CustomerImageWithCustomerDto>(_mapper.ConfigurationProvider).ToListAsync();

            result.Data = CustomerImageDtos;
            return result;
        }

        //[ValidationBehavior(typeof(CreateCustomerImageValidator))]
        //public async Task<Result<int>> CreateCustomerImage(CreateCustomerImageVM createCustomerImageVM)
        //{
        //    var result = new Result<int>();

        //    var customerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Id == createCustomerImageVM.CustomerId);
        //    if (!customerExists)
        //    {
        //        throw new NotFoundException($"{createCustomerImageVM.CustomerId} numaralı kullanıcı bulunamadı.");
        //    }
        //    //Dosyanın ismi belirleniyor.
        //    var fileName = PathUtil.GenerateFileNameFromBase64File(createCustomerImageVM.UploadedImage);
        //    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["Paths:CustomerImages"], fileName);
        //    //Dosya fiziksel olarak kaydediliyor.
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //    {
        //        createCustomerImageVM.UploadedImage.CopyTo(fs);
        //        fs.Close();
        //    }
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //    {
        //        ms.CopyTo(fs);
        //        fs.Close();
        //    }
        //    //Dosyanı yolu [Projenin kök dizininin yolu]+["images"]+"["product-images"]+["dosyanın adı.uzantısı"]

        //    var customerImageEntity = _mapper.Map<CustomerImage>(createCustomerImageVM);
        //    //images/product-images/14_8_2023_21_56_39_987.png
        //    customerImageEntity.Path = Path.Combine(_configuration["Paths:CustomerImages"], fileName);

        //    //Dosyaya ait bilgileri dbye yaz.
        //    _unitWork.GetRepository<CustomerImage>().Add(customerImageEntity);
        //    await _unitWork.CommitAsync();

        //    result.Data = customerImageEntity.Id;
        //    return result;
        //}

        [ValidationBehavior(typeof(CreateCustomerImageValidator))]
        public async Task<Result<int>> CreateCustomerImage(CreateCustomerImageVM createCustomerImageVM)
        {
            var result = new Result<int>();

            var productExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Id == createCustomerImageVM.CustomerId);
            if (!productExists)
            {
                throw new NotFoundException($"{createCustomerImageVM.CustomerId} numaralı kullanıcı bulunamadı.");
            }
            //Dosyanın ismi belirleniyor.
            var fileName = PathUtil.GenerateFileNameFromBase64File(createCustomerImageVM.UploadedImage);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["Paths:CustomerImages"], fileName);


            //Base64 string olarak gelen dosya byte dizisine çevriliyor.
            var imageDataAsByteArray = Convert.FromBase64String(createCustomerImageVM.UploadedImage);
            //byte dizisi FileStream'e yazmak üzere FileStream'e aktarılıyor.
            var ms = new MemoryStream(imageDataAsByteArray);
            ms.Position = 0;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                ms.CopyTo(fs);
                fs.Close();
            }
            //Dosya fiziksel olarak kaydediliyor.
            //using (FileStream fs = new FileStream(filePath, FileMode.Create))
            //{
            //    createCustomerImageVM.UploadedImage.CopyTo(fs);
            //    fs.Close();
            //}

            //Dosyanı yolu [Projenin kök dizininin yolu]+["images"]+"["product-images"]+["dosyanın adı.uzantısı"]

            var CustomerImageEntity = _mapper.Map<CustomerImage>(createCustomerImageVM);
            //images/product-images/14_8_2023_21_56_39_987.png
            CustomerImageEntity.Path = $"{_configuration["Paths:CustomerImages"]}/{fileName}";

            //Dosyaya ait bilgileri dbye yaz.
            _unitWork.GetRepository<CustomerImage>().Add(CustomerImageEntity);
            await _unitWork.CommitAsync();

            result.Data = CustomerImageEntity.Id;
            return result;
        }


        [ValidationBehavior(typeof(DeleteCustomerImageValidator))]
        public async Task<Result<int>> DeleteCustomerImage(DeleteCustomerImageVM deleteCustomerImageVM)
        {
            var result = new Result<int>();

            var existsCustomerImage = await _unitWork.GetRepository<CustomerImage>().GetById(deleteCustomerImageVM.Id);
            if (existsCustomerImage is null)
            {
                throw new NotFoundException($"{deleteCustomerImageVM.Id} numaralı kullanıcı resmi bulunamadı.");
            }

            //Kullanıcı resmine ait db kaydı siliniyor.
            _unitWork.GetRepository<CustomerImage>().Delete(existsCustomerImage);
            await _unitWork.CommitAsync();

            //Fiziksel resim dosyası siliniyor.
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, existsCustomerImage.Path);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            result.Data = existsCustomerImage.Id;
            return result;
        }


    }
}
