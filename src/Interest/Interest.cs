namespace Interest;

public static class Interest
{
    /// <summary>
    /// Calculates the periodic payment for an annuity investment based on constant-amount periodic payments and a constant interest rate.
    /// </summary>
    /// <param name="rate">The interest rate</param>
    /// <param name="numberOfPeriods">The number of payments to be made</param>
    /// <param name="presentValue">The current value of the annuity</param>
    /// <param name="futureValue">The future value remaining after the final payment has been made</param>
    /// <param name="endOrBeginning">Whether payments are due at the end (0) or beginning (1) of each period</param>
    /// <returns>Periodic payment amount</returns>
    public static double PMT(double rate, int numberOfPeriods, double presentValue, double futureValue = 0, int endOrBeginning = 0)
    {
        var pmt =
            rate / (Math.Pow(1 + rate, numberOfPeriods) - 1)
            * -(presentValue * Math.Pow(1 + rate, numberOfPeriods) + futureValue);

        if (endOrBeginning == 1)
            pmt /= 1 + rate;

        return pmt;
    }

    /// <summary>
    /// Calculates the future value of an annuity investment based on constant-amount periodic payments and a constant interest rate.
    /// </summary>
    /// <param name="rate">The interest rate</param>
    /// <param name="numberOfPeriods">The number of payments to be made</param>
    /// <param name="paymentAmount">The amount per period to be paid</param>
    /// <param name="presentValue">The current value of the annuity.</param>
    /// <param name="endOrBeginning">Whether payments are due at the end (0) or beginning (1) of each period.</param>
    /// <returns></returns>
    public static double FV(double rate, int numberOfPeriods, double paymentAmount, double presentValue, int endOrBeginning = 0)
    {
        if (endOrBeginning == 1)
            paymentAmount *= 1 + rate;

        double fv = -((Math.Pow(1 + rate, numberOfPeriods) - 1) / rate * paymentAmount + presentValue
            * Math.Pow(1 + rate, numberOfPeriods));

        return fv;
    }


    /// <summary>
    /// Calculates the payment on interest for an investment based on constant-amount periodic payments and a constant interest rate
    /// </summary>
    /// <param name="rate">The amortization period, in terms of number of periods</param>
    /// <param name="period">The number of payments to be made</param>
    /// <param name="numberOfPeriods">The number of payments to be made</param>
    /// <param name="presentValue">The current value of the annuity</param>
    /// <param name="futureValue">The future value remaining after the final payment has been made</param>
    /// <param name="endOrBeginning">Whether payments are due at the end (0) or beginning (1) of each period</param>
    /// <returns></returns>
    public static double IPMT(double rate, int period, int numberOfPeriods, double presentValue, double futureValue = 0, int endOrBeginning = 0)
    {
        var ipmt = FV(rate, period - 1, PMT(rate, numberOfPeriods, presentValue, futureValue, endOrBeginning), presentValue, endOrBeginning) * rate;

        if (endOrBeginning == 1)
            ipmt /= 1 + rate;

        return ipmt;
    }

    /// <summary>
    /// Calculates the payment on the principal of an investment based on constant-amount periodic payments and a constant interest rate.
    /// </summary>
    /// <param name="rate">The interest rate</param>
    /// <param name="period">The amortization period, in terms of number of periods</param>
    /// <param name="numberOfPeriods">The number of payments to be made</param>
    /// <param name="presentValue">The current value of the annuity</param>
    /// <param name="futureValue">The future value remaining after the final payment has been made</param>
    /// <param name="endOrBeginning">Whether payments are due at the end (0) or beginning (1) of each period</param>
    /// <returns></returns>
    public static double PPMT(double rate, int period, int numberOfPeriods, double presentValue, double futureValue = 0, int endOrBeginning = 0)
    {
        return PMT(rate, numberOfPeriods, presentValue, futureValue, endOrBeginning) -
               IPMT(rate, period, numberOfPeriods, presentValue, futureValue, endOrBeginning);
    }
}
