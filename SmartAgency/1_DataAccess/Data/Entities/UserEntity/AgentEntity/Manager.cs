﻿using SmartAgency._1_DataAccess.Data.Entities.ValueObjects;

namespace SmartAgency._1_DataAccess.Data.Entities.UserEntity.AgentEntity;

public record Manager(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<ClientEntity.Client> ClientList)
    : Agent(Id, FirstName, LastName, Email, DateAdded, ClientList);