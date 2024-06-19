interface ExternalLinkProps {
  url: string;
  children: React.ReactNode;
}

const ExternalLink: React.FC<ExternalLinkProps> = ({ url, children }) => {
  return (
    <a href={url} target="_blank" rel="noopener noreferrer">
      {children}
    </a>
  );
};

export default ExternalLink;