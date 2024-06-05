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

    result1 = process_csv(filePath1, model_path, scaler_path)
    result2 = process_csv(filePath2, model_path, scaler_path)

    results = {
        "Result1": json.loads(result1),
        "Result2": json.loads(result2)
    }

    return json.dumps(results, indent=4)

def main(csv_path):
    model_path = "C:/Users/Usuario/OneDrive/Documentos/Faculdade/9 SEMESTRE/PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I/TCC/PlayerClassifier/PlayerClassifier.WPF/modelo.pkl"
    scaler_path = "C:/Users/Usuario/OneDrive/Documentos/Faculdade/9 SEMESTRE/PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I/TCC/PlayerClassifier/PlayerClassifier.WPF/scaler.pkl"
    return process_csv(csv_path, model_path, scaler_path)
