using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfLessonDal : EfEntityRepositoryBase<Lesson,EducationPortalDb>,ILessonDal
    {

    }
}
