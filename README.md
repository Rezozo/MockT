# MockT
docker run -d -v d:/db:/data/db -p 27017:27017 --name mongodb-base mongo

docker exec -it mongodb-base bash

mongosh

use triangle

db.createCollection("Triangles")
