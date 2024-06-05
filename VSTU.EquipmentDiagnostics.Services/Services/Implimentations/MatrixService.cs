using VSTU.EquipmentDiagnostics.Dal;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Services
{
    public class MatrixService : IMatrixService
    {

        public List<FailureComplect> MatrixToFailureComplects(int[,] matrix, List<Failure> failures, List<RootCause> rootCauses, List<Symptom> symptoms)
        {
            List<FailureComplect> failureComplects = new List<FailureComplect>();

            // Проверка, что размер матрицы и количество отказов, причин и симптомов согласованы
            int numRows = matrix.GetLength(0);
            int numColumns = matrix.GetLength(1);
            int totalFailuresCount = failures.Count;
            int totalRootCausesCount = rootCauses.Count;
            int totalSymptomsCount = symptoms.Count;

            if (numColumns != totalFailuresCount || numRows != (totalFailuresCount + totalRootCausesCount + totalSymptomsCount))
            {
                throw new ArgumentException("Invalid matrix dimensions");
            }

            // Проход по каждому элементу матрицы
            for (int i = 0; i < numColumns; i++)
            {
                FailureComplect failureComplect = new FailureComplect
                {
                    Predecessors = new List<Failure>(),
                    Successors = new List<Failure>(),
                    RootCauses = new List<RootCause>(),
                    Symptoms = new List<Symptom>()
                };

                for (int j = 0; j < numRows; j++)
                {
                    int value = matrix[j, i];

                    // Создание комплекта отказа на основе значения элемента матрицы
                    switch (value)
                    {
                        case >= 1:
                            if (i < totalFailuresCount)
                            {
                                // Добавление предшественника                      
                                failureComplect.Predecessors.Add(failures[j]);
                                
                            }
                            else if (i >= totalFailuresCount && i < (totalFailuresCount + totalRootCausesCount))
                            {
                                // Присутствует причина
                                RootCause rootCause = rootCauses[j - totalFailuresCount];
                                failureComplect.RootCauses.Add(rootCause);
                            }
                            else if (i >= (totalFailuresCount + totalRootCausesCount))
                            {
                                // Присутствует симптом
                                Symptom symptom = symptoms[j - (totalFailuresCount + totalRootCausesCount)];
                                failureComplect.Symptoms.Add(symptom);
                            }
                            else
                            {
                                // Неверное значение
                                throw new ArgumentException("Invalid matrix value");
                            }
                            break;
                        case <=-1: // Последователь
                            if (j < totalFailuresCount)
                            {
                                failureComplect.Successors.Add(failures[j]);
                            }
                            else
                            {
                                // Неверное значение
                                throw new ArgumentException("Invalid matrix value");
                            }
                            break;
                    }
                }
                // Добавление созданного комплекта отказа в список
                failureComplects.Add(failureComplect);
            }
            return failureComplects;
        }
    }
}
