﻿namespace BLogic.EzAdmin.Data.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open BLogic.EzAdmin.Data.Engines.EngineRepository
open BLogic.EzAdmin.Domain.SchemaTypes
open BLogic.EzAdmin.Core.Engines.DescriptionConverter
open BLogic.EzAdmin.Data.Core
open MongoDB.Driver

[<TestClass>]
type MsSqlSchemaRepositoryTest () =
//    let complexTable: TableSchema = {SchemaName = "dbo"; TableName = "Users"; Columns = [
//                      {
//                        ColumnName = "UserID";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.PrimaryKey;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "FirstName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "LastName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "UserID";
//                        TableName = "UserApplications";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.ForeignKey;
//                        Reference = Some {
//                            ColumnName = "UserID";
//                            TableName = "Users";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.PrimaryKey;
//                            Reference = Option.None;
//                            IsHidden = false;
//                          };
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "ApplicationID";
//                        TableName = "Applications";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.ForeignKey;
//                        Reference = Some {
//                            ColumnName = "ApplicationID";
//                            TableName = "UserApplications";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.Column;
//                            Reference = Option.None;
//                            IsHidden = false;
//                          };
//                        IsHidden = true;
//                      };
//                      {
//                        ColumnName = "Name";
//                        TableName = "Applications";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                    ]}

//    [<TestMethod>]
//    member this.ExecuteDynamicQuery_Simple_NoJoins () =
//        let table: TableSchema = {SchemaName = "dbo"; TableName = "Users"; Columns = [
//                      {
//                        ColumnName = "UserID";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.PrimaryKey;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "FirstName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "LastName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                    ]}
//        let c = table |> convertToDescription |> getDynamicQueryResults |> Seq.toList
//        Assert.IsTrue(c.Length > 0);
//        Assert.AreEqual(3, c.Head.Columns.Length);

//    [<TestMethod>]
//    member this.ExecuteDynamicQuery_OneJoin_TwoColumns () =
//        let table: TableSchema = {SchemaName = "dbo"; TableName = "UserApplications"; Columns = [
//                      {
//                        ColumnName = "UserID";
//                        TableName = "UserApplications";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.PrimaryKey;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "FirstName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Some {
//                            ColumnName = "UserID";
//                            TableName = "Users";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.ForeignKey;
//                            Reference = Some {
//                                ColumnName = "UserID";
//                                TableName = "UserApplications";
//                                SchemaName = "dbo";
//                                ColumnType = ColumnType.PrimaryKey;
//                                Reference = Option.None;
//                                IsHidden = true;
//                            }
//                            IsHidden = true;
//                        };
//                        IsHidden = false;
//                      };
//                    ]}

//        let c = table |> convertToDescription |> getDynamicQueryResults |> Seq.toList
//        Assert.IsTrue(c.Length > 0);
//        Assert.AreEqual(2, c.Head.Columns.Length);

//    [<TestMethod>]
//    member this.ExecuteDynamicQuery_OneJoin_ThreeColumns () =
//        let table: TableSchema = {SchemaName = "dbo"; TableName = "UserApplications"; Columns = [
//                      {
//                        ColumnName = "UserID";
//                        TableName = "UserApplications";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.PrimaryKey;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "FirstName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Some {
//                            ColumnName = "UserID";
//                            TableName = "Users";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.ForeignKey;
//                            Reference = Some {
//                                ColumnName = "UserID";
//                                TableName = "UserApplications";
//                                SchemaName = "dbo";
//                                ColumnType = ColumnType.PrimaryKey;
//                                Reference = Option.None;
//                                IsHidden = true;
//                            }
//                            IsHidden = true;
//                        };
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "LastName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Some {
//                            ColumnName = "UserID";
//                            TableName = "Users";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.ForeignKey;
//                            Reference = Some {
//                                ColumnName = "UserID";
//                                TableName = "UserApplications";
//                                SchemaName = "dbo";
//                                ColumnType = ColumnType.PrimaryKey;
//                                Reference = Option.None;
//                                IsHidden = true;
//                            }
//                            IsHidden = true;
//                        };
//                        IsHidden = false;
//                      };
//                    ]}

//        let c = table |> convertToDescription |> getDynamicQueryResults |> Seq.toList
//        Assert.IsTrue(c.Length > 0);
//        Assert.AreEqual(3, c.Head.Columns.Length);

//    [<TestMethod>]
//    member this.ExecuteDynamicQuery_TwoJoins_FourColumns () =
//        let table: TableSchema = {SchemaName = "dbo"; TableName = "UserApplications"; Columns = [
//                      {
//                        ColumnName = "UserID";
//                        TableName = "UserApplications";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.PrimaryKey;
//                        Reference = Option.None;
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "FirstName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Some {
//                            ColumnName = "UserID";
//                            TableName = "Users";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.ForeignKey;
//                            Reference = Some {
//                                ColumnName = "UserID";
//                                TableName = "UserApplications";
//                                SchemaName = "dbo";
//                                ColumnType = ColumnType.PrimaryKey;
//                                Reference = Option.None;
//                                IsHidden = true;
//                            }
//                            IsHidden = true;
//                        };
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "LastName";
//                        TableName = "Users";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Some {
//                            ColumnName = "UserID";
//                            TableName = "Users";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.ForeignKey;
//                            Reference = Some {
//                                ColumnName = "UserID";
//                                TableName = "UserApplications";
//                                SchemaName = "dbo";
//                                ColumnType = ColumnType.PrimaryKey;
//                                Reference = Option.None;
//                                IsHidden = true;
//                            }
//                            IsHidden = true;
//                        };
//                        IsHidden = false;
//                      };
//                      {
//                        ColumnName = "Name";
//                        TableName = "Applications";
//                        SchemaName = "dbo";
//                        ColumnType = ColumnType.Column;
//                        Reference = Some {
//                            ColumnName = "ApplicationID";
//                            TableName = "Applications";
//                            SchemaName = "dbo";
//                            ColumnType = ColumnType.ForeignKey;
//                            Reference = Some {
//                                ColumnName = "ApplicationID";
//                                TableName = "UserApplications";
//                                SchemaName = "dbo";
//                                ColumnType = ColumnType.PrimaryKey;
//                                Reference = Option.None;
//                                IsHidden = true;
//                            }
//                            IsHidden = true;
//                        };
//                        IsHidden = false;
//                      };
//                    ]}

//        let c = table |> convertToDescription |> getDynamicQueryResults |> Seq.toList
//        Assert.IsTrue(c.Length > 0);
//        Assert.AreEqual(4, c.Head.Columns.Length);
    [<TestMethod>]
    member this.ExecuteDynamicQuery_OneJoin_TwoColumns () =
        NamelessInteractive.FSharp.MongoDB.SerializationProviderModule.Register()
        NamelessInteractive.FSharp.MongoDB.Conventions.ConventionsModule.Register()

        let apps = MongoHandler.appCollection().FindSync(FilterDefinition.Empty).First()

        Assert.IsTrue(true);
