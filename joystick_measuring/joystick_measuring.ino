const int pinX = A0;
const int pinY = A1;

void setup() {
  Serial.begin(9600);
}

void loop() {
  // Lees de analoge waarden af (geeft een waarde tussen 0 en 1023)
  int xWaarde = analogRead(pinX);
  int yWaarde = analogRead(pinY);

  // Print de waarden naar de Seriële Monitor
  Serial.print("X-as: ");
  Serial.print(xWaarde);
  Serial.print(" | Y-as: ");
  Serial.println(yWaarde);

  delay(100);
}