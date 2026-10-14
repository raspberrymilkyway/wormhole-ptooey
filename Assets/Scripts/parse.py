import json

def do():
    rooms = ["bridge", "cabin", "captain's quarters", "hallway", "medbay", "mess hall", "storage bay"]
    intRoom = "room 1"
    itemEtDesc = {}
    roomIndex = 0
    started = False
    roomsCleared = 0

    with open("itemDescriptions.md", "r", encoding="utf-8") as file:
        lines = [line.rstrip() for line in file]
    
    with open("itemDescriptions.json", "w") as fi:
        fi.write("{\n\"room\":[")
        for line in lines:
            if line == "" or line[0] == "(":
                continue
            if "####" in line:
                n = line[5:].strip(" *")
                if "1" not in n:
                    serialize(fi, rooms[roomIndex], intRoom, itemEtDesc)
                    itemEtDesc = {}
                intRoom = n
            elif "###" in line:
                if started == True:
                    serialize(fi, rooms[roomIndex], intRoom, itemEtDesc)
                    roomsCleared += 1
                else:
                    started = True
                roomIndex = rooms.index(line[3:].strip(" *"))
                intRoom = "room 1"
                itemEtDesc = {}
            else:
                desc = line.split(" - ", 1)
                itemEtDesc[desc[0]] = desc[1]
        
        serialize(fi, rooms[roomIndex], intRoom, itemEtDesc, True)
        fi.write("\n]\n}")

def serialize(fi, room, internalRoom, itemAndDescription, last=False):
    if "mess" in room:
        room = room + " " + internalRoom.split(" ")[1]

    data = {"name": room, "itemPlus": itemAndDescription}
    json.dump(data, fi, indent=4)
    if not last:
        fi.write(",\n")

do()