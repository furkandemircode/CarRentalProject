﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public IResult Add(Brand brand)
    {
        if (brand.Name.Length <= 2)
        {
            return new ErrorResult(Messages.BrandNameIsInvalid);
        }
        _brandDal.Add(brand);

        return new SuccessResult(Messages.AddedBrand);
    }

    public IResult Delete(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult(Messages.DeleteBrand);
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ListedBrand);
    }

    public IDataResult<Brand> GetById(int id)
    {
        return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id), Messages.ListedByBrandId);
    }

    public IResult Update(Brand brand)
    {
        _brandDal.Update(brand);

        return new SuccessResult(Messages.UpdatedBrand);
    }



}
