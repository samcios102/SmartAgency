using SmartAgency.Data.Entities.User.ValueObjects;

namespace SmartAgency.Data.Entities.User;

public record User(Name FirstName, Name LastName, Email Email, DateOnly AddedDate); 





//comparer i toString

// copy/ clone

// var user1 = user2 with { FirstName = "Gary}


// dont need to serializa and deserialize json ... no more :D
