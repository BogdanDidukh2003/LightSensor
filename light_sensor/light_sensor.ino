#define POT_PIN 33
#define SENSOR_1_PIN 26 // light up with led
#define SENSOR_2_PIN 27 // external
#define LED_PIN 25

int response;
int inputVal = 0;
int extLightVal = 0;
int intLightVal = 0;
int oldInputVal = 0;
byte wholePacket[6] = {0x00};
byte inputPacket[2] = {0x00};
unsigned long innerTime;
unsigned long prevTime = 0;

bool delayTimer(int duration){
  if (prevTime == 0) { 
    prevTime = millis();
    return true;
  }
  if((millis() - prevTime) > duration*1000 ) {
    prevTime = millis();
    return true;
  }
  return false;  
}

void sendWholePacket(){
  wholePacket[0] = highByte(extLightVal);
  wholePacket[1] = lowByte(extLightVal);
  wholePacket[2] = highByte(intLightVal);
  wholePacket[3] = lowByte(intLightVal);
  wholePacket[4] = highByte(inputVal);
  wholePacket[5] = lowByte(inputVal);
  Serial.write(wholePacket, 6);
}
  void sendInputPacket(){
  inputPacket[0] = highByte(inputVal);
  inputPacket[1] = lowByte(inputVal);
  Serial.write(inputPacket, 2);
}
void setup()
{
  Serial.begin(9600);
  pinMode(LED_PIN, OUTPUT);
  pinMode(SENSOR_1_PIN, INPUT);
  pinMode(SENSOR_2_PIN, INPUT);
  pinMode(POT_PIN, INPUT);
  inputVal = analogRead(POT_PIN) /100*25;
}

void loop()
{ 
  if(Serial.available()){
      response = Serial.read();
      if (response == 0xA1){
        digitalWrite(LED_PIN, HIGH);
        }
        
      if (response == 0xB1){
        digitalWrite(LED_PIN, LOW);
        }
    }
  if (delayTimer(5)){
    extLightVal = analogRead(SENSOR_2_PIN)/100*25;
    intLightVal = analogRead(SENSOR_1_PIN)/100*25;
    if (inputVal < extLightVal - 5) digitalWrite(LED_PIN, HIGH); // add send data
    if (inputVal > extLightVal + 5) digitalWrite(LED_PIN, LOW);
    sendWholePacket();
    return;
  }else
  {
  oldInputVal = inputVal;
  inputVal = analogRead(POT_PIN) /100*25;
  if(inputVal != oldInputVal) {
    oldInputVal = inputVal;
    delay(10);
    inputVal = analogRead(POT_PIN) /100*25;
    sendInputPacket();
  }
  }
  delay(50);
}
