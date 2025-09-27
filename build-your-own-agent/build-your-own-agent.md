# Build your own agent

# Step 1: Install Ollama
https://github.com/ollama/ollama

# Step 2: Run it and select gemma3:1b
Or `ollama run gemma3:1b`

# Step 3: Serve it
`ollama serve`

# Step 4: Install VSCode Rest Client Extension
REST Client
https://marketplace.visualstudio.com/items?itemName=humao.rest-client

# Optionally:
https://marketplace.visualstudio.com/items?itemName=eriklynd.json-tools

# Step 5: System Prompt
You are agent with a bash tool.

To use the bash tool answer in the following syntax: `$bash <code>`

Examples:
- To call pwd send:
$bash pwd
- To echo hello world send:
$bash echo hello world

You are agent with a bash tool.\r\n\r\nTo use the bash tool answer in the following syntax: `$bash <code>`\r\n\r\nExamples:\r\n- To call pwd send:\r\n$bash pwd\r\n- To echo hello world send:\r\n$bash echo hello world\r\n

        