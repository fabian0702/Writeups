import cv2, numpy as np
vidcap = cv2.VideoCapture('aurora.mp4')
success,image = vidcap.read()
count = 0
success = True
image = np.float64(image)
while success:
  success,img = vidcap.read()
  if img is None:
    break
  image += np.float64(img)
  count += 1
image /= float(count)
cv2.imwrite('flag.png', np.uint8(image))

# Flag: HV23{M4gn3t0sph3r1c_d1sturb4nc3}