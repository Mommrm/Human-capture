import socket
import cv2
from cvzone.PoseModule import PoseDetector

# 读取cv来源，也可以调用摄像头使用
cap = cv2.VideoCapture(0)
img_Shape = (500,500)

detector = PoseDetector()
posList = []

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)



while True:
    success, img = cap.read()
    img = detector.findPose(img)
    
    img = cv2.resize(img , img_Shape)
    lmList, bboxInfo = detector.findPosition(img)
    data = []

    if bboxInfo:
        
        for lm in lmList:
            data.extend([lm[1],img.shape[0] - lm[2],lm[3]])
        
    sock.sendto(str.encode(str(data)), serverAddressPort)        
    print(data)
    
    cv2.imshow("Image", img)
    key = cv2.waitKey(1)
    
            

