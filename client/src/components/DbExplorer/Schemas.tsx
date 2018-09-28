import * as React from "react";
import { Header, List } from "semantic-ui-react";
import {
  DB_SCHEMAS_QUERY,
  DbSchemasQueryComponent
} from "../../graphql/queries/DbExplorer/SchemasQuery";

type Props = {
  onSchemaClick: (schemaName: string) => void;
};

class Schemas extends React.Component<Props> {
  public render() {
    return (
      <>
        <DbSchemasQueryComponent query={DB_SCHEMAS_QUERY}>
          {response => {
            if (!response.loading && response.data) {
              return (
                <>
                  <Header content="Schemas of db" />
                  <List
                    size="large"
                    divided={true}
                    animated={true}
                    celled={true}
                  >
                    {response.data.schemas.map(x => {
                      return (
                        <List.Item
                          key={x.schemaName}
                          onClick={() => this.props.onSchemaClick(x.schemaName)}
                        >
                          {x.schemaName}
                        </List.Item>
                      );
                    })}
                  </List>
                </>
              );
            }
            return null;
          }}
        </DbSchemasQueryComponent>
      </>
    );
  }
}

export { Schemas };
