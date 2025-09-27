# Feel?
- Awesome
- Interresting
- Liked to Demystifying the AgentLoop by implementing a simple version of it
- Easy
- Expected more
- Its just a model that speaks some text and you make sense out of it
- GPT: So much effort around a model

# Learn
- Modern CSharp is nice (last used it in version 8)
- Basic Architecture of an Agent
  - 3 Roles
  - Model
  - Loop
  - ToolCaller
  - User
  - ChatProtocol
- Distinction between System Role and Assistant Role
  - System Role: How you model what the model would give back
    - System Prompt
  - Assistant Role: Responsible for the interaction  
  - There is no distinction between a User and a Toolcallers from the perspective of the AgentLoop
    - The Toolcaller result becomes a User Message
    - By doing it this way the loop gets easier, we dont have to differentiate

# Went well
- Pretty complete implementation
