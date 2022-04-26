using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Results.State;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonDal LessonDal { get; }
        public LessonManager(ILessonDal lessonDal)
        {
            LessonDal = lessonDal;
        }

        [SecuredOperation("lesson.edit|lesson.any|lesson.add")]
        public IResult Add(Lesson lesson)
        {
            LessonDal.Add(lesson);
            return new SuccessResult(Messages.SuccessAddOperation);
        }

        [SecuredOperation("lesson.edit|lesson.any|lesson.delete")]
        public IResult Delete(Lesson lesson)
        {
            LessonDal.Delete(lesson);
            return new SuccessResult(Messages.SuccessDeleteOperation);
        }

        public IListDataResult<Lesson> GetLessons()
        {
            return new SuccessListDataResult<Lesson>(LessonDal.GetAll());
        }

        [SecuredOperation("lesson.edit|lesson.any|lesson.update")]
        public IResult Update(Lesson lesson)
        {
            LessonDal.Update(lesson);
            return new SuccessResult(Messages.SuccessUpdateOperation);
        }

        public ISingleDataResult<Lesson> GetByLessonId(int lessonId)
        {
            return new SuccessSingleDataResult<Lesson>(LessonDal.Get(lesson => lesson.Id == lessonId));
        }
    }
}
