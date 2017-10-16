const int nota_do = 12;
const int nota_re = 11;
const int nota_mi = 10;
const int nota_fa = 9;
const int trigger = 13;
volatile byte estado = HIGH;
int inicia = false;

const unsigned long duracao_nota_do = 45;  //11 Hertz  -- porta 12 
const unsigned long duracao_nota_re = 56;  //9 Hertz  -- porta 11
const unsigned long duracao_nota_mi = 38;  //13 Herz   -- porta 10
const unsigned long duracao_nota_fa = 71;  //7Hertz -- porta 9 

unsigned long temporizador_nota_do = 0;
unsigned long temporizador_nota_re = 0;
unsigned long temporizador_nota_mi = 0;
unsigned long temporizador_nota_fa = 0;
unsigned long temporizador = 0;

int estado_do = 0;
int estado_re = 0;
int estado_mi = 0;
int estado_fa = 0;

void setup(void)
{
  Serial.begin(9600);
    pinMode(nota_do, OUTPUT);
    pinMode(nota_re, OUTPUT);
    pinMode(nota_fa, OUTPUT);
    pinMode(nota_mi, OUTPUT);
    pinMode(trigger, OUTPUT);
    pinMode(3, INPUT);    
    attachInterrupt(digitalPinToInterrupt(3), setTrigger, CHANGE);
    digitalWrite(trigger, estado);
}

void setTrigger()
{
  inicia = !inicia;
  estado = !estado;
  digitalWrite(trigger, estado);
}

void loop() 
{
  if(inicia)
  {
    temporizador = millis();
  
    if (temporizador - temporizador_nota_do >= duracao_nota_do) 
    {
      temporizador_nota_do = temporizador;
      if (estado_do == LOW) { estado_do = HIGH; }     
      else {estado_do = LOW;}
      digitalWrite(nota_do, estado_do);   
    }
  
    if (temporizador - temporizador_nota_re >= duracao_nota_re) 
    {
      temporizador_nota_re = temporizador;
  
      if (estado_re == LOW)     {      estado_re = HIGH;    } 
      else     {      estado_re = LOW;    }
      digitalWrite(nota_re, estado_re);
    }
  
    if (temporizador - temporizador_nota_mi >= duracao_nota_mi) 
    {
      temporizador_nota_mi = temporizador;
  
      if (estado_mi == LOW)     {      estado_mi = HIGH;    } 
      else     {      estado_mi = LOW;    }
      digitalWrite(nota_mi, estado_mi);
    }
  
    if (temporizador - temporizador_nota_fa >= duracao_nota_fa) 
    {
      temporizador_nota_fa = temporizador;
  
      if (estado_fa == LOW)     {      estado_fa = HIGH;    } 
      else     {      estado_fa = LOW;    }
      digitalWrite(nota_fa, estado_fa);
    }
  }  
  else
  {
    digitalWrite(nota_do, LOW);
    digitalWrite(nota_re, LOW);
    digitalWrite(nota_mi, LOW);
    digitalWrite(nota_fa, LOW);
    
    
    }
}
