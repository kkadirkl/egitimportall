using Entities.Concrete;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILessonService
    {
        IResult Add(Lesson lesson);
        IResult Delete(Lesson lesson);
        IResult Update(Lesson lesson);

        IListDataResult<Lesson> GetLessons();
        ISingleDataResult<Lesson> GetByLessonId(int lessonId);
    }
}
