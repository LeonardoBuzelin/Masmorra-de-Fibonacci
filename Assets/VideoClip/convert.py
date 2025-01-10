import os

VIDEOS = [ "Fibunnachi's Dungeon - Intro", 
            "Fibunnachi's Dungeon - Menu",
            "Fibunnachi's Dungeon - Morrendo 1",
            "Fibunnachi's Dungeon - Morrendo 2",
            "Fibunnachi's Dungeon - Morrendo 3",
            "Fibunnachi's Dungeon - Sala 1",
            "Fibunnachi's Dungeon - Sala 2",
            "Fibunnachi's Dungeon - Sala 3",
            "Fibunnachi's Dungeon - You Win"
        ]

for video in VIDEOS:
    os.system('ffmpeg -y -i "' + video + '.mp4" -c:v vp8 -crf 15 -b:v 10000k -b:a 128k -c:a libvorbis "' + video + '.webm"')

os.system("rm *.mp4")
