using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeinCvSitesi.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var personel = new List<PersonalInfo>()
            {
                new PersonalInfo(){NameSurname="emrah Eskibağcı", PhoneNumber="534565987", Email="emrah@gmail", UserName="emraheskbgc"},
                new PersonalInfo(){NameSurname="lale Eskibağcı", PhoneNumber="555555555", Email="lale@gmail",UserName="laleeskbgc"},
                new PersonalInfo(){NameSurname="yeter Eskibağcı", PhoneNumber="666666666", Email="yeter@gmail",UserName="yetereskbgc"}

            };
            foreach (var item in personel)
            {
                context.PersonalInfos.Add(item);
            }
            context.SaveChanges();
            

            var skill = new List<Skill>()
            {
                new Skill(){SkillName="c#", Degree="85",UserName="emraheskbgc"},
                new Skill(){SkillName="c++", Degree="85",UserName="emraheskbgc"},
                new Skill(){SkillName="java", Degree="55",UserName="laleeskbgc"},
                new Skill(){SkillName="phyton", Degree="75",UserName="yetereskbgc"}

            };
            foreach (var item in skill)
            {
                context.Skills.Add(item);
            }
            context.SaveChanges();
            

            var experience = new List<Experience>() 
            { 
                new Experience(){WorkplaceName="rookie", WorkYear="2017",Description="personal trainer",UserName="emraheskbgc"},
                new Experience(){WorkplaceName="mis başak", WorkYear="2010",Description="pasteria chef", UserName="laleeskbgc"},
                new Experience(){WorkplaceName="my home", WorkYear="1993",Description="home woman", UserName="yetereskbgc"}
            };
            foreach (var item in experience)
            {
                context.Experiences.Add(item);
            }
            context.SaveChanges();

            var education = new List<EducationInfo>()
            {
                new EducationInfo(){SchoolName="aksaray üniversitesi",Departman="YBS", Year="2017",UserName="emraheskbgc" },
                new EducationInfo(){SchoolName="hacettepe üniversitesi",Departman="turizm", Year="2015",UserName="laleeskbgc" },
                new EducationInfo(){SchoolName="mehmetcik ilkokul",Departman="ilk", Year="2000", UserName="yetereskbgc" }
            };
            foreach (var item in education)
            {
                context.EducationInfos.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}