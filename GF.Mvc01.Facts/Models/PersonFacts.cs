using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using GF.Mvc01.Models;

namespace GF.Mvc01.Facts.Models
{
    public class PersonFacts
    {
        //[Fact]
        //public void MustBeMaleOrFemale()
        //{
        //    // arrange
        //    Person p = new Person();

        //    //Assert.Throws<Exception>(() =>
        //    //{

        //    //});
        //    // action 
        //    // assert ตรวจสอบ

        //}

        public class TheGenDerProperty
        {

            private Person p;

            public TheGenDerProperty()
            {

                p = new Person();
            }
            [Fact]
            public void CanAcceptsMale()
            {
                p.Gender = "M";
                Assert.Equal("M", p.Gender);
            }
            [Fact]
            public void CantAcceptsOtherGenders()
            {

                Assert.Throws<Exception>(() =>
                {
                    p.Gender = "X";
                });
            }
        }

        public class TheMarryMethod
        {
            //private Person p1 = new Person();
            //private Person p2 = new Person();

            [Fact]
            public void ThrowsExceptionIfAgeLessThan20Years()
            {

                Person p1 = new Person();

                Person p2 = new Person();

                int thisYear = DateTime.Now.Year;

                p1.BirthYear = thisYear - 15; // 15 yo.

                p2.BirthYear = thisYear - 30; // 30 yo.

                //Assert.Throws(typeof(Exception), () => {

                // p1.Marry(p2);

                //});

                Assert.Throws<Exception>(() =>
                {

                    p1.Marry(p2);

                });

            }


            //[Fact]
            //public void BothAgesMustNotLessThan20Years()
            //{ 
            //    p1.BirthYear = 1986;
            //    p2.BirthYear = 1985;

            //    Assert.DoesNotThrow(() =>
            //    {
            //        p1.Marry(p2);
            //    });
            //}
            [Fact]
            public void MaleCannotMarryToMale()
            {
                Person p1 = new Person();

                Person p2 = new Person();

                p1.Gender = "M";

                p2.Gender = "M";

                Assert.Throws<Exception>(() =>
                {
                  p1.Marry(p2);
                });
            }
            [Fact]
            public void MaleCanMarryToFemale()
            {
                Person p1 = new Person();

                Person p2 = new Person();

                p1.Gender = "M";

                p2.Gender = "F";

                Assert.DoesNotThrow(() =>
                {
                    p1.Marry(p2);
                });
            }



            [Fact]
            public void ShouldReturnFamily()
            {
                Person p1 = new Person();

                Person p2 = new Person();

                p1.Gender = "M";

                p2.Gender = "F";

                Family f = p1.Marry(p2);

                Assert.NotNull(f);

            }

        }
        [Fact]
        public void MarriedPersonHasFamily()
        {
            Person p1 = new Person() { Gender = "M" };
            Person p2 = new Person() { Gender = "F" };
            p1.Marry(p2);

            Assert.NotNull(p1.Family);
            Assert.NotNull(p2.Family);
            Assert.Same(p1.Family, p2.Family);
        
        }

        [Fact]

        public void FamilyHasHusbandAndWife()
        {

            Person p1 = new Person() { Gender = "M" };

            Person p2 = new Person() { Gender = "F" };

            Family f = p1.Marry(p2);

            Assert.Same(f.Husband, p1);

            Assert.Same(f.Wife, p2);

        }

        [Fact]
        public void BirthYearInPastOrPresentIsOkay()
        {
            //arrange
            Person p = new Person();
            int thisYear = DateTime.Now.Year;

            //asset
            Assert.DoesNotThrow(() =>
            {

                //action (assume this year is 2012)
                p.BirthYear = thisYear;

            });
            Assert.Equal(thisYear, p.BirthYear);
        }

        [Fact]
        public void BirthYeadIsNotInTherFutrue()
        {

            Person p = new Person(); // arrange เตรียม

            //Assert ถ้า รัน Code นี้จะโยน Exception
            Assert.Throws<Exception>(() =>
            {
                p.BirthYear = DateTime.Now.Year + 1;  //p.BirthYear = 3000;  // action (assume this year is 2012) เอาค่าไปใส่   //Asset ต้อง Throw Exception  ถึงจะ เขียวว ผ่าน    
            });

        }

        public class TheGetAgeMethod
        {
            [Fact]
            public void ShouldReturnValidAge()
            {

                Person p = new Person();
                int thisYear = DateTime.Now.Year;
                //p.BirthYear = thisYear - 12;
                p.BirthYear = thisYear;
                int age = p.GetAge();

                Assert.Equal(0, age);
                Assert.True(age <= 12);
            }

        }
    }
}
