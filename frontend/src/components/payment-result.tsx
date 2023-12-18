interface Props {
  fee: number;
}

const PaymentResult = ({ fee }: Props) => {
  return (
    <div className="flex flex-col p-5 bg-blue-50 mt-5 items-center">
      Your total fee for the day was:
      <span className="text-blue-600 text-3xl mt-5">{fee} SEK</span>
    </div>
  );
};

export default PaymentResult;
