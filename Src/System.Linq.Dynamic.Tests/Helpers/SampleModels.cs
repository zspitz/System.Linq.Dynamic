﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq.Dynamic.Tests.Helpers
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public UserProfile Profile { get; set; }

        public static IList<User> GenerateSampleModels(int total, bool allowNullableProfiles = false)
        {
            Validate.Argument(total).IsInRange(x => total >= 0).Check();

            var list = new List<User>();

            for (int i = 0; i < total; i++)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "User" + i.ToString()
                };

                if (!allowNullableProfiles || (i % 8) != 5)
                {
                    user.Profile = new UserProfile()
                    {
                        FirstName = "FirstName" + i,
                        LastName = "LastName" + i,
                        Age = (i % 50) + 18
                    };
                }

                list.Add(user);
            }

            return list.ToArray();
        }
    }

    public class UserProfile
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }
    }
}