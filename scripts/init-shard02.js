rs.initiate(
   {
      _id: "shard02",
      version: 1,
      members: [
         { _id: 0, host : "shard02a:27019" },
         { _id: 1, host : "shard02b:27019" },
      ]
   }
)

// Allow reading from mongo shell.
rs.slaveOk()
