namespace BookingRoom.TAF.StepDefinitions.TransformationSteps
{
    [Binding]
    public class SharedTransformationSteps
    {
        [StepArgumentTransformation("'(present|not present)'")]
        [StepArgumentTransformation("'(exists|not exists)'")]
        [StepArgumentTransformation("'(available|not available)'")]
        public bool TransformPresentNotPresent(string text)
        {
            return text switch
            {
                "not present" or "not exists" or "not available" => false,
                "present" or "exists" or "available" => true,
                _ => throw new ArgumentException("Incorrect Format")
            };
        }
    }
}
