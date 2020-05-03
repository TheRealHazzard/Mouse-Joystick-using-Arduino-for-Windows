int pushPin = 7;   
int xPin = 0;
int yPin = 1;
int xMove = 0;
int yMove = 0;
int valPush = HIGH;    
int valX = 0;
int valY = 0;
void setup()
{
  pinMode(pushPin,INPUT);
  Serial.begin(9600);       
  digitalWrite(pushPin,HIGH);
}

void loop()
{
  valX = analogRead(xPin);  
  valY = analogRead(yPin);   
  valPush = digitalRead(pushPin);
  
  Serial.println(String(valX) + " " + String(valY) + " " + valPush);    
}
