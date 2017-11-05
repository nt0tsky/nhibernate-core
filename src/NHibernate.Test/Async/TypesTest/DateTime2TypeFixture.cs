﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using NHibernate.Driver;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NUnit.Framework;

namespace NHibernate.Test.TypesTest
{
	using System.Threading.Tasks;
	/// <summary>
	/// TestFixtures for the <see cref="DateTimeType"/>.
	/// </summary>
	[TestFixture]
	[Obsolete]
	public class DateTime2TypeFixtureAsync : AbstractDateTimeTypeFixtureAsync
	{
		protected override bool AppliesTo(Dialect.Dialect dialect) =>
			TestDialect.SupportsSqlType(SqlTypeFactory.DateTime2);

		protected override bool AppliesTo(Engine.ISessionFactoryImplementor factory) =>
			// Cannot handle DbType.DateTime2 via .Net ODBC.
			!(factory.ConnectionProvider.Driver is OdbcDriver);

		protected override string TypeName => "DateTime2";
		protected override AbstractDateTimeType Type => NHibernateUtil.DateTime2;
	}

	[TestFixture]
	[Obsolete]
	public class DateTime2TypeWithScaleFixtureAsync : DateTimeTypeWithScaleFixtureAsync
	{
		protected override bool AppliesTo(Dialect.Dialect dialect) =>
			TestDialect.SupportsSqlType(SqlTypeFactory.DateTime2);

		protected override bool AppliesTo(Engine.ISessionFactoryImplementor factory) =>
			// Cannot handle DbType.DateTime2 via .Net ODBC.
			!(factory.ConnectionProvider.Driver is OdbcDriver);

		protected override string TypeName => "DateTime2WithScale";
		protected override AbstractDateTimeType Type => (AbstractDateTimeType)TypeFactory.GetDateTime2Type(3);
	}
}