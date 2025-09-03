To run Python Azure Function locally, follow these steps:

Navigate to your Python Functions directory:
```bash
   cd c:\SourceControl\SecurityStrategyPoC\Python\Functions
```

(Optional) Create and activate a virtual environment:
```bash
   python -m venv .venv
```
```bash
   .\.venv\Scripts\Activate
```

Install dependencies:
```bash
   pip install -r requirements.txt
```

Start the Azure Functions host:
```bash
   func start
```

This will start your Python Azure Function locally.
You can then test your HTTP-triggered function at:
```bash
   http://localhost:7071/api/http_trigger_get_weather
```