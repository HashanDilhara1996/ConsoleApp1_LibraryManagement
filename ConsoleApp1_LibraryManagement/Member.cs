using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_LibraryManagement
{
    class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string ContactNum { get; set; }

        public static void RegisterMember(List<Member> libraryMembers)
        {
            Console.WriteLine("Register a New Member:");
            Console.Write("Member ID: ");
            int memberId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Contact Number: ");
            string contactNum = Console.ReadLine();

            // Create a new member instance with user-provided data
            Member newMember = new Member
            {
                MemberID = memberId,
                Name = name,
                ContactNum = contactNum
            };

            // Add the new member to the library's records
            libraryMembers.Add(newMember);

            Console.WriteLine($"Member '{name}' (ID: {memberId}) has been registered.");
        }

        public static void DisplayAllMembers(List<Member> members)
        {
            Console.WriteLine("List of Registered Members:");
            foreach (var member in members)
            {
                Console.WriteLine($"Member ID: {member.MemberID}, Name: {member.Name}, Contact Info: {member.ContactNum}");
                Console.WriteLine("=============================================================================================");
            }
        }
    }

}
