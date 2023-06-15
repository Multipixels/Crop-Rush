from PIL import Image
import os

# get the directory path of the current python file
my_path = os.path.dirname("test.png")


im = Image.open(r"C:\Users\RIC\Desktop\Unity Projects\Crop Rush\test\test.png")
pix = im.load()

mapValues = []

print(pix[0,0])

for i in range(25):
    temp = []
    for j in range(47):
        x = 0
        if pix[j,i] == (0,0,0):
            x = 1
        if pix[j,i] == (255,255,255):
            x = 0
        if pix[j,i] == (253,236,166):
            x = 2
        if pix[j,i] == (255,28,36):
            x = 4
        if pix[j,i] == (255,202,24):
            x = 5
        if pix[j,i] == (184,61,186):
            x = 6
        if pix[j,i] == (0,168,243):
            x = 7
        temp.append(x)

    mapValues.append(temp)

print(mapValues)

for y in mapValues:
    print(y)