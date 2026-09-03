const int pinX = A0;
const int pinY = A1;
const int CLK_PIN = 2;
const int DT_PIN = 3;
const int BTN_PIN = 4;

int lastStateCLK;
int currentStateCLK;

// Non-blocking timer for joystick intervals
unsigned long lastJoystickTime = 0;
const unsigned long JOYSTICK_INTERVAL = 50;  // 50ms update rate for C#
int buttonState = 0;                         // variable for reading the pushbutton status


void setup() {
  Serial.begin(9600);

  // Use internal pull-up resistors to prevent floating pin noise
  pinMode(CLK_PIN, INPUT_PULLUP);
  pinMode(DT_PIN, INPUT_PULLUP);
  pinMode(BTN_PIN, INPUT);
  lastStateCLK = digitalRead(CLK_PIN);
}

void loop() {
  // -------------------------------------------------------------
  // 1. FAST ROTARY ENCODER POLLING (Runs as fast as possible)
  // -------------------------------------------------------------
  currentStateCLK = digitalRead(CLK_PIN);

  // Trigger on falling edge (transition to LOW)
  if (currentStateCLK != lastStateCLK && currentStateCLK == LOW) {
    // Determine direction by reading DT pin relative to CLK
    if (digitalRead(DT_PIN) != currentStateCLK) {
      Serial.println("RUp");
    } else {
      Serial.println("RDown");
    }
  }
  lastStateCLK = currentStateCLK;



  // -------------------------------------------------------------
  // 2. NON-BLOCKING JOYSTICK SAMPLING (Runs every 50ms)
  // -------------------------------------------------------------
  unsigned long currentMillis = millis();
  if (currentMillis - lastJoystickTime >= JOYSTICK_INTERVAL) {
    lastJoystickTime = currentMillis;

    int xRaw = analogRead(pinX);
    int yRaw = analogRead(pinY);

    // Y-Axis (Up/Down)
    if (yRaw > 600) {
      Serial.println("UP");
    } else if (yRaw < 400) {
      Serial.println("DOWN");
    }

    // X-Axis (Left/Right Reversed)
    if (xRaw < 400) {
      Serial.println("RIGHT");
    } else if (xRaw > 600) {
      Serial.println("LEFT");
    }
    digitalWrite(BTN_PIN, HIGH);
    buttonState = digitalRead(BTN_PIN);
    // check if the pushbutton is pressed. If it is, the buttonState is HIGH:
    if (buttonState == LOW) {
      // press the fish button
      Serial.println("BTN");
    }
  }
}