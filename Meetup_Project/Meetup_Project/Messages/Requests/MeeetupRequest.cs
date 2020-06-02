using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Validators;
using Meetup_Project.Messages.Responses;


namespace Meetup_Project.Messages.Requests
{
    public class MeeetupRequest
    {
        public string Name { get; set; }
        public string Organizer { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public ICollection<LectureDto> Lectures { get; set; }


    }

    public class LectureDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
    }

    public class MeetupRequestValidator: AbstractValidator<MeeetupRequest>
    {
        public MeetupRequestValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3);
            RuleFor(x => x.Organizer)
                .NotEmpty();
            
        }
    }

    public class LectureValidator: AbstractValidator<LectureDto>
    {
        public LectureValidator()
        {
            RuleFor(x => x.Author)
                .NotEmpty();
            RuleFor(x => x.Topic)
                .NotEmpty();
        }
    }
}
