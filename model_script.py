import pandas as pd
import json
import joblib  # Importe joblib diretamente

def process_csv(file_path, model_path, scaler_path):
    df = pd.read_csv(file_path)

    scaler = joblib.load(scaler_path)
    model = joblib.load(model_path)

    features = df.iloc[:, 0:26].values
    scaled_features = scaler.transform(features)

    predictions = model.predict(scaled_features)
    df['prediction'] = predictions

    result_json = df.to_json(orient='records')
    return result_json

def comparePlayers(userFiles):
    data = json.loads(userFiles)
    filePath1 = data['FilePath1']
    filePath2 = data['FilePath2']

    model_path = "C:/Users/Usuario/OneDrive/Documentos/Faculdade/9 SEMESTRE/PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I/TCC/PlayerClassifier/PlayerClassifier.WPF/modelo.pkl"
    scaler_path = "C:/Users/Usuario/OneDrive/Documentos/Faculdade/9 SEMESTRE/PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I/TCC/PlayerClassifier/PlayerClassifier.WPF/scaler.pkl"

    result1 = json.loads(process_csv(filePath1, model_path, scaler_path))
    result2 = json.loads(process_csv(filePath2, model_path, scaler_path))

    prediction1 = result1[0]['prediction']
    prediction2 = result2[0]['prediction']

    if prediction1 > prediction2:
        comparison_result = {
            "Result1": filePath1,
            "Result2": filePath2,
            "GreaterResult": "Result1"
        }
    elif prediction1 < prediction2:
        comparison_result = {
            "Result1": filePath1,
            "Result2": filePath2,
            "GreaterResult": "Result2"
        }
    else:
        comparison_result = {
            "Result1": filePath1,
            "Result2": filePath2,
            "GreaterResult": "Equal"
        }

    return json.dumps(comparison_result, indent=4)

def main(csv_path):
    model_path = "C:/Users/Usuario/OneDrive/Documentos/Faculdade/9 SEMESTRE/PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I/TCC/PlayerClassifier/PlayerClassifier.WPF/modelo.pkl"
    scaler_path = "C:/Users/Usuario/OneDrive/Documentos/Faculdade/9 SEMESTRE/PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I/TCC/PlayerClassifier/PlayerClassifier.WPF/scaler.pkl"
    return process_csv(csv_path, model_path, scaler_path)
