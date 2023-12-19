interface Props {
  passages: Date[];
}

const PassagesList = ({ passages }: Props) => {
  return (
    <div className="flex flex-col">
      {passages && (
        <>
          <span className="text-blue-400 text-center font-bold">
            List of passages
          </span>
          {passages.map((passage, i) => {
            return (
              <div
                key={i}
                className="bg-blue-200 rounded mt-1 py-1 px-2 flex justify-between text-blue-700"
              >
                <span>{passage.toLocaleDateString()}</span>
                <span>{passage.toLocaleTimeString().split(" ")[0]}</span>
              </div>
            );
          })}
        </>
      )}
    </div>
  );
};

export default PassagesList;
