const int CLK_PIN = 2;
const int DT_PIN = 3;

int lastStateCLK;
int currentStateCLK;

void setup() {
  Serial.begin(9600);
  
  pinMode(CLK_PIN, INPUT);
  pinMode(DT_PIN, INPUT);
  
  lastStateCLK = digitalRead(CLK_PIN);
}

void loop() {
  currentStateCLK = digitalRead(CLK_PIN);
  
  // Detect rotation
  if (currentStateCLK != lastStateCLK && currentStateCLK == 1) {
    if (digitalRead(DT_PIN) != currentStateCLK) {
      Serial.println("Down");
    } else {
      Serial.println("Up");
    }
  }
  
  lastStateCLK = currentStateCLK;
}
