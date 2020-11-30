using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.WebAPI.Models.Test
{
    public class TestCreateRequest : TestCreateDTO
    {
    }

    public class TestQuestionCreateRequest : TestQuestionCreateDTO
    {

    }


    public class TestAnswerCreateRequest : TestAnswerVariantCreateDTO
    {
    }


    public class TestScheduleCreateRequest : TestScheduleCreateDTO
    {
    }

    public class TestEditRequest : TestEditDTO
    {
    }

    public class TestQuestionEditRequest : TestQuestionEditDTO
    {

    }


    public class TestAnswerEditRequest : TestAnswerVariantEditDTO
    {
    }


    public class TestScheduleEditRequest : TestScheduleEditDTO
    {
    }

    public class TestDeleteRequest
    {
        public int Id { get; set; }
    }

    public class TestQuestionDeleteRequest
    {
        public int Id { get; set; }
    }

    public class TestAnswerDeleteRequest 
    {
        public int Id { get; set; }
    }


    public class TestScheduleDeleteRequest
    {
        public int Id { get; set; }
    }
}
