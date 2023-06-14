using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace FamilyPrinter.Test
{
    [TestClass]
    public class PrinterTest
    {
        [TestMethod]
        public void PrintDepth1Test()
        {
            string expected = "*GrandDad\r\n  -Aunt\r\n  -Uncle\r\n  *Dad\r\n    -Me\r\n    -Sister\r\n";

            Ancestor myAncestor =
            new Ancestor
            {
                Name = "GrandDad",
                Children = new List<Person> {
            new Child { Name = "Aunt" },
            new Child { Name = "Uncle" },
            new Parent { Name = "Dad",
                Children = new List<Person> {
                    new Child { Name = "Me" },
                    new Child { Name = "Sister" } }
            }
        }
            };

            var output = FamilyPrinter.Print(myAncestor);

            Assert.IsTrue(expected == output);
        }

        [TestMethod]
        public void PrintDepth2Test()
        {
            string expected = "*GrandDad\r\n  -Aunt\r\n  -Uncle\r\n  *Dad\r\n    -Me\r\n    -Sister\r\n    *Me2\r\n      -Me2Son\r\n      -Me2Sister\r\n";

            Ancestor myAncestor =
            new Ancestor
            {
                Name = "GrandDad",
                Children = new List<Person> {
            new Child { Name = "Aunt" },
            new Child { Name = "Uncle" },
            new Parent { Name = "Dad",
                Children = new List<Person> {
                    new Child { Name = "Me" },
                    new Child { Name = "Sister" },
                    new Parent { Name = "Me2",
                Children = new List<Person> {
                    new Child { Name = "Me2Son" },
                    new Child { Name = "Me2Sister" } }
            }

                }
            },
        }
            };

            var output = FamilyPrinter.Print(myAncestor);


            Assert.IsTrue(expected == output);

        }

        [TestMethod]
        public void PrintDepth3Test()
        {
            string expected = "*GrandDad\r\n  -Aunt\r\n  -Uncle\r\n  *Dad\r\n    -Me\r\n    -Sister\r\n    *Me2\r\n      -Me2Son\r\n      -Me2Sister\r\n  -ChotaDad\r\n";

            Ancestor myAncestor =
            new Ancestor
            {
                Name = "GrandDad",
                Children = new List<Person> {
            new Child { Name = "Aunt" },
            new Child { Name = "Uncle" },
            new Parent { Name = "Dad",
                Children = new List<Person> {
                    new Child { Name = "Me" },
                    new Child { Name = "Sister" },
                    new Parent { Name = "Me2",
                            Children = new List<Person> {
                                new Child { Name = "Me2Son" },
                                new Child { Name = "Me2Sister" } }
                        }

                }
            },
            new Child { Name = "ChotaDad" }
        }
            };

            var output = FamilyPrinter.Print(myAncestor);


            Assert.IsTrue(expected == output);

        }

        [TestMethod]
        public void PrintDepth4Test()
        {
            string expected = "*GrandDad\r\n  -Aunt\r\n  -Uncle\r\n  *Dad\r\n    -Me\r\n    -Sister\r\n    *Me2\r\n      -Me2Son\r\n      -Me2Sister\r\n      *Me2Son2\r\n        -Me2Son2Son\r\n        -Me2Son2Sister\r\n      *Me2Son3\r\n        -Me2Son3Son\r\n        -Me2Son3Sister\r\n  -ChotaDad\r\n  *ChotaDad2\r\n    -Me\r\n    -Sister\r\n    *Me2\r\n      -Me2Son\r\n      -Me2Sister\r\n";

            Ancestor myAncestor =
            new Ancestor
            {
                Name = "GrandDad",
                Children = new List<Person> {
            new Child { Name = "Aunt" },
            new Child { Name = "Uncle" },
            new Parent { Name = "Dad",
                Children = new List<Person> {
                    new Child { Name = "Me" },
                    new Child { Name = "Sister" },
                    new Parent { Name = "Me2",
                            Children = new List<Person> {
                                new Child { Name = "Me2Son" },
                                new Child { Name = "Me2Sister" },
                            new Parent { Name = "Me2Son2",
                            Children = new List<Person> {
                                new Child { Name = "Me2Son2Son" },
                                new Child { Name = "Me2Son2Sister" } }
                        },
                            new Parent { Name = "Me2Son3",
                            Children = new List<Person> {
                                new Child { Name = "Me2Son3Son" },
                                new Child { Name = "Me2Son3Sister" } }
                        }}
                        }
                }
            },
            new Child { Name = "ChotaDad" },
            new Parent { Name = "ChotaDad2",
                Children = new List<Person> {
                    new Child { Name = "Me" },
                    new Child { Name = "Sister" },
                    new Parent { Name = "Me2",
                            Children = new List<Person> {
                                new Child { Name = "Me2Son" },
                                new Child { Name = "Me2Sister" } }
                        }
                }
            },
        }
            };

            var output = FamilyPrinter.Print(myAncestor);


            Assert.IsTrue(expected == output);

        }
    }
}
