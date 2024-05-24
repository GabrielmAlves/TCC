import pandas as pd
import json
import sys
from sklearn.externals import joblib

def process_csv(file_path, model_path, scaler_path):
    
    df = pd.read_csv(file_path)


    scaler = joblib.load(scaler_path)
    model = joblib.load(model_path)

   
    features = df.iloc[:, 0:26].values

    scaled_features = scaler.transform(features)

    predictions = model.predict(scaled_features)

    df['prediction'] = predictions

    # Converter DataFrame para JSON
    result_json = df.to_json(orient='records')

    return result_json

if __name__ == "__main__":
    if len(sys.argv) > 2:
        csv_path = sys.argv[1]
        model_path = "C:\Users\Usuario\OneDrive\Documentos\Faculdade\9 SEMESTRE\PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I\TCC\PlayerClassifier\PlayerClassifier.WPF\modelo.pkl"
        scaler_path = "C:\Users\Usuario\OneDrive\Documentos\Faculdade\9 SEMESTRE\PROJETO FINAL EM ENGENHARIA DE COMPUTAÇÃO I\TCC\PlayerClassifier\PlayerClassifier.WPF\scaler.pkl"
        result = process_csv(csv_path, model_path, scaler_path)
        print("\nResultado do modelo:", result)
    else:
        print("Algo deu errado..")