﻿namespace BLogic.EzAdmin.Data.Core
module MongoHandler = 
    open MongoDB.Driver
    open BLogic.EzAdmin.Domain.SchemaTypes
    open BLogic.EzAdmin.Domain.Users

    [<Literal>]
    let ConnectionString = "mongodb://localhost:27017/ezadmin"
    [<Literal>]
    let DbName = "ezadmin"

    let getClient() = MongoClient(ConnectionString)
    let getDb() = getClient().GetDatabase(DbName)

    let appCollection() = getDb().GetCollection<AppSchema>("apps")

    let userCollection() = getDb().GetCollection<User>("users")

