﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Linq;
using NHibernate.Linq;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH3951
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override void OnSetUp()
		{
			using (ISession session = OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				var e1 = new Entity {Name = "Bob"};
				session.Save(e1);

				var e2 = new Entity {Name = "Sally"};
				session.Save(e2);

				session.Flush();
				transaction.Commit();
			}
		}

		protected override void OnTearDown()
		{
			using (ISession session = OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Delete("from System.Object");

				session.Flush();
				transaction.Commit();
			}
		}

		[Test]
		public async Task AllNamedBobAsync()
		{
			using (ISession session = OpenSession())
			using (session.BeginTransaction())
			{
				var result = await (session.Query<Entity>()
					.AllAsync(e => e.Name == "Bob"));

				Assert.AreEqual(false, result);
			}
		}

		[Test]
		public async Task AllNamedWithAtLeast3CharAsync()
		{
			using (ISession session = OpenSession())
			using (session.BeginTransaction())
			{
				var result = await (session.Query<Entity>()
					.AllAsync(e => e.Name.Length > 2));

				Assert.AreEqual(true, result);
			}
		}

		[Test]
		public async Task AllNamedBobWorkaroundAsync()
		{
			using (ISession session = OpenSession())
			using (session.BeginTransaction())
			{
				var result = !await (session.Query<Entity>()
					.AnyAsync(e => e.Name != "Bob"));

				Assert.AreEqual(false, result);
			}
		}

		[Test]
		public async Task AllNamedWithAtLeast3CharWorkaroundAsync()
		{
			using (ISession session = OpenSession())
			using (session.BeginTransaction())
			{
				var result = !await (session.Query<Entity>()
					.AnyAsync(e => e.Name.Length < 3));

				Assert.AreEqual(true, result);
			}
		}

		[Test]
		public async Task AnyAndAllInSubQueriesAsync()
		{
			using (ISession session = OpenSession())
			using (session.BeginTransaction())
			{
				var result = await (session.Query<Entity>()
					.Select(e => new { e.Id, hasRelated = e.Related.Any(), allBobRelated = e.Related.All(r => r.Name == "Bob") })
					.ToListAsync());

				Assert.AreEqual(false, result[0].hasRelated);
				Assert.AreEqual(true, result[0].allBobRelated);
			}
		}
	}
}